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

  const getValue = () => {
       
    if (options && field) {
        var r = isMulti
        ? options.filter(option => field.value.indexOf(option.value) >= 0)
        : options.find(option => option.value === field.value);                
        console.log(r);
        return r;
    } else {
      return isMulti ? [] : ("");
    }
  };

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