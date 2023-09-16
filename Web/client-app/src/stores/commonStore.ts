import { makeAutoObservable, reaction } from "mobx";
import DrawerItem from "../models/Drawer";
import DirectionsRunOutlinedIcon from "@mui/icons-material/DirectionsRunOutlined";
import BugReportOutlinedIcon from "@mui/icons-material/BugReportOutlined";
import AssignmentOutlinedIcon from "@mui/icons-material/AssignmentOutlined";
import ConfirmationNumberOutlinedIcon from "@mui/icons-material/ConfirmationNumberOutlined";
import DescriptionOutlinedIcon from "@mui/icons-material/DescriptionOutlined";

export default class CommonStore {
  token: string | null = window.localStorage.getItem("jwt");
  appLoaded: boolean = false;

  constructor() {
    makeAutoObservable(this);

    reaction(
      () => this.token,
      (token) => {
        if (token) {
          window.localStorage.setItem("jwt", token);
        } else {
          window.localStorage.removeItem("jwt");
        }
      }
    );
  }

  get isLoggedIn() {
    return !!this.token;
  }

  setToken = (token: string | null) => {
    if (token) window.localStorage.setItem("jwt", token);
    this.token = token;
  };

  setAppLoaded = () => {
    this.appLoaded = true;
  };

  getDrawerItems = (): DrawerItem[] => {
    return [
      {
        text: "Sprints",
        icon: DirectionsRunOutlinedIcon,
      },
      {
        text: "Issues",
        icon: BugReportOutlinedIcon,
      },
      {
        text: "Tasks",
        icon: AssignmentOutlinedIcon,
      },
      {
        text: "Tickets",
        icon: ConfirmationNumberOutlinedIcon,
      },
      {
        text: "Notes",
        icon: DescriptionOutlinedIcon,
      },
    ];
  };
}
