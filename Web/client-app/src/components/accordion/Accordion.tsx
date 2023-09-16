import React from "react";
import AccordionItem from "./AccordionItem";
import { Grid } from "@mui/material";

export default function Accordion() {
  return (
    <>
      <Grid container>
        <Grid item xs={3}>
          {/* {sprints.map((sprint) => (
            <AccordionItem
              key={sprint.id}
              name={sprint.title}
              caption={sprint.startDate}
            />
          ))} */}
        </Grid>
        <Grid item xs={9}></Grid>
      </Grid>
    </>
  );
}
