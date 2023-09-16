import { ReactElement } from "react";

export default interface Modal {
  open: boolean;
  body: ReactElement | null;
}
