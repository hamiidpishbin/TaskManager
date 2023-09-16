import { makeAutoObservable } from "mobx";
import Modal from "../models/Modal";
import { ReactElement } from "react";

export default class ModalStore {
  modal: Modal = {
    open: false,
    body: null,
  };

  constructor() {
    makeAutoObservable(this);
  }

  openModal = (body: ReactElement | null) => {
    this.modal.open = true;
    this.modal.body = body;
  };

  closeModal = () => {
    this.modal.open = false;
    this.modal.body = null;
  };
}
