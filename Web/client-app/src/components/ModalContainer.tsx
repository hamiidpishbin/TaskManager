import React from "react";
import { Modal } from "@mui/material";
import { useStore } from "../stores/store";

export default function ModalContainer() {
  const { modalStore } = useStore();
  return (
    <Modal open={modalStore.modal.open} onClose={modalStore.closeModal}>
      {modalStore.modal.body!}
    </Modal>
  );
}
