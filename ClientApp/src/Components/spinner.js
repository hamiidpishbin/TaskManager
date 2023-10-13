import React from "react";

const Spinner= ({ center, className, style }) => {
  return (
    <div
      className={`spinner ${
        center && "flex justify-center items-center"
      }  ${className}`}
    >
      <div className="bounce1" style={style}></div>
      <div className="bounce2" style={style}></div>
      <div className="bounce3" style={style}></div>
    </div>
  );
};

export default Spinner;
