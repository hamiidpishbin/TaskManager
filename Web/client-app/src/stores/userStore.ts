import { makeAutoObservable, runInAction } from "mobx";
import { User } from "../models/User";
import agent from "../api/agent";
import { SignupForm } from "../models/SignupForm";
import { toast } from "react-toastify";
import { LoginForm } from "../models/LoginForm";
import { store } from "./store";

export default class UserStore {
  user: User | null = null;

  constructor() {
    makeAutoObservable(this);
  }

  signup = async (signupFormValues: SignupForm) => {
    const user = await agent.Account.signup(signupFormValues);
    if (!user) {
      toast.error("error happened");
    }
  };

  login = async (formValues: LoginForm) => {
    try {
      const user = await agent.Account.login(formValues);
      runInAction(() => (this.user = user));
      store.commonStore.setToken(user.token);
    } catch (error) {
      throw error;
    }
  };

  logout = () => {
    store.commonStore.setToken(null);
    window.localStorage.removeItem("jwt");
    this.user = null;
  };
}
