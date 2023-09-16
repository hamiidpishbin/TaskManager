import axios, { AxiosError, AxiosResponse } from "axios";
import { SignupForm } from "../models/SignupForm";
import { User } from "../models/User";
import { toast } from "react-toastify";
import { LoginForm } from "../models/LoginForm";
import { store } from "../stores/store";
import { Sprint } from "../models/Sprint";

axios.defaults.baseURL = "http://localhost:8000/api";

axios.interceptors.request.use((config) => {
  const token = store.commonStore.token;
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  console.log("Token: ", token);

  return config;
});

const onAxiosFulfilled = async (response: any) => response;
const onAxiosRejected = (error: AxiosError) => {
  const { data, status, config }: { data: any; status: number; config: any } =
    error.response!;
  switch (status) {
    case 400:
      if (typeof data === "string") {
        toast.error(data);
      }

      if (config.method === "get" && data.errors.hasOwnProperty("id")) {
        toast.error("Not Found");
      }
      if (data.errors) {
        const modalStateErrors = [];
        for (const [key] of Object.entries(data.errors)) {
          if (!data.errors[key]) continue;
          modalStateErrors.push(data.errors[key]);
        }
        throw modalStateErrors.flat();
      }
      break;
    case 401:
      toast.error("Unauthorized");
      break;
    case 404:
      toast.error("Not Found");
      break;
    case 500:
      toast.error("Server Error");
      break;
  }
  return Promise.reject(error);
};

axios.interceptors.response.use(onAxiosFulfilled, onAxiosRejected);

const getResponseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(getResponseBody),
  post: <T>(url: string, body: {}) =>
    axios.post<T>(url, body).then(getResponseBody),
  put: <T>(url: string, body: {}) =>
    axios.put<T>(url, body).then(getResponseBody),
  delete: <T>(url: string) => axios.delete<T>(url).then(getResponseBody),
};

const Account = {
  signup: (formValues: SignupForm) =>
    requests.post<User>("/account/signup", formValues),
  login: (formValues: LoginForm) =>
    requests.post<User>("/account/login", formValues),
};

const Sprints = {
  GetAll: () => requests.get<Sprint[]>("/sprint"),
};

const agent = {
  Account,
  Sprints,
};

export default agent;
