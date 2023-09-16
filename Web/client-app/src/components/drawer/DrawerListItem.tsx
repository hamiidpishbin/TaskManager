import React from "react";
import {
  Icon,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import DrawerItem from "../../models/Drawer";
import { useNavigate } from "react-router-dom";

export interface Props {
  drawerItem: DrawerItem;
  open: boolean;
}

export default function DrawerListItem({ drawerItem, open }: Props) {
  const { text, icon } = drawerItem;
  const navigate = useNavigate();

  function handleDrawerItemClick(itemName: string): void {
    navigate(`/${itemName}`);
  }

  return (
    <ListItem key={text} disablePadding sx={{ display: "block" }}>
      <ListItemButton
        sx={{
          minHeight: 48,
          justifyContent: open ? "initial" : "center",
          px: 2.5,
        }}
        onClick={() => handleDrawerItemClick(text)}
      >
        <ListItemIcon
          sx={{
            minWidth: 0,
            mr: open ? 3 : "auto",
            justifyContent: "center",
          }}
        >
          {<Icon component={icon} />}
        </ListItemIcon>
        <ListItemText primary={text} sx={{ opacity: open ? 1 : 0 }} />
      </ListItemButton>
    </ListItem>
  );
}
