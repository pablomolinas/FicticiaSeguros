import axios from "axios";
import React, { useContext, useState } from "react";
import combineUrl from "../helpers/combineUrl";
import UserContext from "../context/UserContext";
import {Navigate} from "react-router-dom";
import {API_URL} from '../Constants';

const initialValue = {
    email:"",
    password:""
}

export const useLogin = (validationLoginForm) => {
    const [loading, setLoading] = useState(false);
    const [form, setForm] = useState(initialValue);
    const [errors, setError] = useState({});
    //const navigate = useNavigate();
    let {setUser} = useContext(UserContext);
    let url = combineUrl(API_URL, "auth/login");
    let body = {
        email: form.email,
        password: form.password
    }
    

    const iniciarSesion = () => {
        setLoading(true);

        setTimeout(() => {
            axios({
                method: 'post',
                //headers: { 'Content-Type': 'application/json'},
                url: url,
                data: body
            })
            .then((res) => {
                const token = res.data.data;                
                localStorage.setItem('token', token);
                setLoading(false);
                setUser(true);
                return <Navigate to="/" />
            })
            .catch((err) => {                
                setLoading(false);
                if(err.response.status === 400) {
                    setError({login: "Credenciales invalidas."})
                    return;
                }else{
                    setError({login: err})
                }
                console.log(err);
            });
        }, 2000);          
        
      };

    const handleChange = (e) => {    
        setForm({
            ...form,
            [e.target.name]:e.target.value
        });
    }
    const handleSubmit = (e) => {
        e.preventDefault();
        handleChange(e);
        setForm(initialValue);
        setError(validationLoginForm(form));
        iniciarSesion();
    }

    const handleBlur = (e) => {
        handleChange(e);
        setError(validationLoginForm(form));
    }

    return {
        form,
        errors,
        handleChange,
        handleSubmit,
        loading,
        handleBlur
    }
}
