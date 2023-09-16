import React from "react";
import List from "@mui/material/List";
import DrawerItem from "../../models/Drawer";
import DrawerListItem from "./DrawerListItem";

export interface Props {
  drawerItems: DrawerItem[];
  open: boolean;
}

export default function DrawerList({ drawerItems, open }: Props) {
  return (
    <List>
      {drawerItems.map((drawerItem) => (
        <DrawerListItem
          key={drawerItem.text}
          drawerItem={drawerItem}
          open={open}
        />
      ))}
    </List>
  );
}
