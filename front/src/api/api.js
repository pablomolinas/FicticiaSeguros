import {API_URL} from '../Constants';
import axios from "axios";
import combineUrl from '../helpers/combineUrl';

const getConfig = () => {
    const token = localStorage.getItem("token");        
    return { headers: { Authorization: `Bearer ${token}` } };
}

export const getPersons = async () => {
    try{        
        const url = combineUrl(API_URL, "persons");
        const response = await axios.get(url, getConfig());            
        
        if(response.status === 200){
            return response.data.data;
        }        
    }catch(e){
      console.log(e);
    }

    return []
}

export const deletePerson = async (person) => {
    try{    
        const url = combineUrl(API_URL, "persons");    
        const response = await axios.delete(`${url}/${person.id}`, getConfig());            
        
        if(response.status === 200){
            return true;
        }        
    }catch(e){
      console.log(e);
    }
    return false;
}

export const updatePerson = async (person) => {
    try{
        const url = combineUrl(API_URL, "persons");
        const response = await axios.put(`${url}/${person.id}`, person, getConfig());            
        
        if(response.status === 200){        
            return true;
        }            
        
    }catch(e){
      console.log(e);
    }
    return false;
}

export const newPerson = async (person) => {
    try{
        //delete person.id;
        const url = combineUrl(API_URL, "persons");
        const response = await axios.post(url, person, getConfig());            
        
        if(response.status === 200){        
            return response.data.data;
        }            
        
    }catch(e){
      console.log(e);
    }
    return false;
}

export const getDiseases = async () => {
    try{        
        const url = combineUrl(API_URL, "diseases");
        const response = await axios.get(url, getConfig());            
        
        if(response.status === 200){
            return response.data.data;
        }        
    }catch(e){
      console.log(e);
    }

    return []
}