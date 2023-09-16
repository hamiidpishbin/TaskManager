import * as React from "react";
import { default as MuiListItem } from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
import IconButton from "@mui/material/IconButton";
import { AddCircleOutlined } from "@mui/icons-material";

export default function ListItem() {
  return (
    <MuiListItem
      secondaryAction={
        <IconButton edge="end" aria-label="comments">
          <AddCircleOutlined />
        </IconButton>
      }
      disablePadding
    >
      <ListItemButton role={undefined}>
        {/* <ListItemText primary={sprint.title} /> */}
      </ListItemButton>
    </MuiListItem>
  );
}
