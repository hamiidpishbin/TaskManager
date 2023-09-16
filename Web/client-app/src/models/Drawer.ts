import { SvgIconTypeMap } from "@mui/material";
import { OverridableComponent } from "@mui/material/OverridableComponent";
import { ReactNode } from "react";

export default interface DrawerItem {
  text: string;
  icon: OverridableComponent<SvgIconTypeMap<{}, "svg">> & { muiName: string };
}
