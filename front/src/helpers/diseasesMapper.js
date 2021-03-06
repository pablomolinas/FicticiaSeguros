
/**
 * diseases: [{id: int, value: string}, ... ,{id: int, value: string}]
 * return: [{value: int, label: string}, ... , {value: int, label: string}]
 */
export const diseasesToSelectItems = (diseases) => {    
    return diseases.map((d) => ({label: d.name, value: d.id}));
}

/**
 * items: [{value: int, label: string}, ... , {value: int, label: string}]
 * return: [{id: int, value: string}, ... ,{id: int, value: string}]
*/
export const SelectItemsToDiseases = (items) => {    
    return items.map((d) => ({id: d.value, name: d.label}));    
}