
/**
 * diseases: [{id: int, value: string}, ... ,{id: int, value: string}]
 * return: [{value: int, label: string}, ... , {value: int, label: string}]
 */
export const diseasesToSelectItems = (diseases) => {    
    return diseases.map((d) => ({label: d.name, value: d.id}));
}

/**
 * items: [int, ... , int]
 * diseasesList: [{value: int, label: string}, ... , {value: int, label: string}]
 * return: [{id: int, value: string}, ... ,{id: int, value: string}]
*/
export const SelectItemsToDiseases = (items, diseasesList) => {

    var filterValues = diseasesList.filter((e) => items.indexOf(e.value) >= 0);
    return filterValues.map((d) => ({id: d.value, name: d.label}));
    
}