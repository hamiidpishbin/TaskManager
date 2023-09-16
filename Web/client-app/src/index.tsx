import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import "react-toastify/dist/ReactToastify.min.css";
import App from "./App";
import { StoreContext, store } from "./stores/store";
import { createBrowserHistory } from "history";
import { BrowserRouter } from "react-router-dom";

export const history: any = createBrowserHistory();

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);
root.render(
  <StoreContext.Provider value={store}>
    <BrowserRouter >
      <App />
    </BrowserRouter>
  </StoreContext.Provider>
);
