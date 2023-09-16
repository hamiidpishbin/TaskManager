import React, { useEffect, useState } from "react";
import { HeadCell } from "../models/table/HeadCell";
import agent from "../api/agent";
import { SprintTableData } from "../models/table/SprintTableData";
import { Sprint as SprintModel } from "../models/Sprint";
import moment from "jalali-moment";
import BaseTable from "../components/Table";

const headCells: HeadCell[] = [
  { id: "title", numeric: false, disablePadding: false, label: "Title" },
  {
    id: "startDate",
    numeric: false,
    disablePadding: false,
    label: "Start Date",
  },
  { id: "endDate", numeric: false, disablePadding: false, label: "End Date" },
];

const createData = (sprints: SprintModel[]): SprintTableData[] => {
  var result: SprintTableData[] = [];

  sprints.forEach((sprint) => {
    result.push({
      id: sprint.id,
      title: sprint.title,
      startDate: moment(sprint.startDate).locale("fa").format("YYYY/MM/DD"),
      endDate: moment(sprint.endDate).locale("fa").format("YYYY/MM/DD"),
    });
  });

  return result;
};

export default function Sprint() {
  const [tableData, SetTableData] = useState<SprintTableData[]>([]);

  useEffect(() => {
    agent.Sprints.GetAll()
      .then((result) => SetTableData(createData(result)))
      .catch((error) => console.log(error));
  }, []);

  return <BaseTable headCells={headCells} rows={tableData} tableTitle="Sprints" />;
}
