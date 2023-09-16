import { FormControl } from "@mui/material";
import { Form, Formik } from "formik";
import React from "react";

interface FormValues {
  sprintName: string;
  startDate: number;
  endDate: number;
}

export default function AddSprintForm() {
  const initialValues: FormValues = {
    sprintName: "",
    startDate: Date.now(),
    endDate: Date.now(),
  };

  const handleSubmit = (values: any, actions: any) => {
    console.log({ values, actions });
  };

  return (
    <Formik initialValues={initialValues} onSubmit={handleSubmit}>
      <Form>
        <FormControl>
          
        </FormControl>
      </Form>
    </Formik>
  );
}
