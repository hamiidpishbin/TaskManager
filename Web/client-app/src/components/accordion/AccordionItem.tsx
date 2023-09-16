import * as React from "react";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import Typography from "@mui/material/Typography";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";

export interface Props {
  name: string;
  caption: string;
}

export default function AccordionItem({ name, caption }: Props) {
  return (
    <div>
      <Accordion>
        <AccordionSummary
          expandIcon={<ExpandMoreIcon />}
          aria-controls="panel1a-content"
          id="panel1a-header"
        >
          <Typography>{name}</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Typography>{caption}</Typography>
        </AccordionDetails>
      </Accordion>
    </div>
  );
}
