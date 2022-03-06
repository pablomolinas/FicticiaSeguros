
export const validationLoginForm = (form) => {
    let errors = {};
    let regexEmail = /^(\w+[/./-]?){1,}@[a-z]+[/.]\w{2,}$/;
    let regexPass = /^[0-9a-zA-Z]{6,}$/;    

    if (!form.email.trim()) {
        errors.email = "Email es requerido"
    } else if (!regexEmail.test(form.email.trim())) {
        errors.email = "Email es inválido"
    }

    if (!form.password.trim()) {
        errors.password = "Contraseña es requerida"
    } else if (!regexPass.test(form.password.trim())) {
        errors.password = "Contraseña invalida (al menos 6 caracteres, a-z, A-Z, 0-9)"
    }
    
    return errors
}

