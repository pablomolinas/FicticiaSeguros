import React from 'react';
import { useContext }  from "react";
import {Navigate} from "react-router-dom";
import NavMenu from "../components/NavMenu";
import Persons from "../components/Persons";
import UserContext from "../context/UserContext";
import 'bootstrap/dist/css/bootstrap.min.css';


export default function Home() {
    let {user} = useContext(UserContext);
    if(!user) return <Navigate to="/login" />
    
    return(
        <>
        <NavMenu/>
        <Persons/>        
        </>
    )
}