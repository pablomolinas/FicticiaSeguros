
export const validationPersonForm = (form) => {
    const errors = {};
    let regexDni = /^[0-9]{7,9}$/;
    let regexName = /^[ÁÉÍÓÚA-Za-z][a-záéíóú]+(\s+[ÁÉÍÓÚA-Z]?[a-záéíóú]+)*$/;    
    
    if (!form.dni || !form.dni.trim()) {
        errors.dni = "Dni es requerido";
    } else if (!regexDni.test(form.dni.trim())) {
        errors.dni = "Dni inválido, solo admite numeros (entre 7 y 9 digitos)"
    }

    if (!form.firstName || !form.firstName.trim()) {
        errors.firstName = "Nombre es requerido";
    }else if (!regexName.test(form.firstName.trim())) {
        errors.firstName = "Nombre tiene un formato inválido"
    }

    if (!form.lastName || !form.lastName.trim()) {
        errors.lastName = "Apellido es requerido";
    }else if (!regexName.test(form.lastName.trim())) {
        errors.lastName = "Apellido tiene un formato inválido"
    }

    if (!form.age) {
        errors.age = "Edad es requerida";
    } else if (isNaN(form.age) || parseInt(form.age) <= 0) {
        errors.age = "Edad debe ser numero mayor que 0"
    } else if (parseInt(form.age) > 110) {
        errors.age = "Edad debe ser numero menor que 110"
    }

    if (!form.gender || !form.gender.trim()) {
        errors.gender = "Sexo es requerido";
    } else if (form.gender.trim() !== "HOMBRE" && form.gender.trim() !== "MUJER") {
        errors.gender = "Sexo tiene un nombre inválido"
    }

    return errors;
}