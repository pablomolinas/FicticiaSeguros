import React from 'react';
import {useContext} from "react"; 
import UserContext from "../context/UserContext";
import {Navigate} from "react-router-dom";

export default function Logout() {
    let userContext = useContext(UserContext);  
    
    userContext.setUser(false);       
    localStorage.removeItem("token");    
    return <Navigate to="/login"/>    
}