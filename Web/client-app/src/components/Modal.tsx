import { Box, Modal as MuiModal, Typography } from "@mui/material";
import React, { ReactElement } from "react";

interface BasicModalProps {
  open: boolean;
  onClose: () => void;
  children: ReactElement;
}

export default function Modal(props: BasicModalProps) {
  const { open, onClose, children } = props;

  const style = {
    position: "absolute" as "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: 400,
    bgcolor: "background.paper",
    border: "2px solid #000",
    boxShadow: 24,
    p: 4,
  };

  return (
    <MuiModal
      open={open}
      onClose={onClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
    >
      <Box sx={style}>{children}</Box>
    </MuiModal>
  );
}
