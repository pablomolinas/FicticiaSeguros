import React from "react";
import Select from "react-select";

export const CustomSelect = ({
  className,
  placeholder,
  field,
  form,
  options,
  isMulti = false
}) => {


  return (
    <Select 
      className={className}
      name={field.name}
      value={field.value}
      onChange={(option) => {form.setFieldValue(field.name, option)}}
      onBlur={field.onBlur}
      placeholder={placeholder}
      options={options}
      isMulti={isMulti}      
    />
  );
};

export default CustomSelect;