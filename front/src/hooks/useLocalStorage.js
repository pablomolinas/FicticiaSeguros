import {useState} from 'react';

export const useLocalStorage = (key, initialValue = "") => {
    const [storedValue, setStoredValue] = useState(() => {
        try{
            const item = window.localStorage.getItem(key);            
            return item ? item : initialValue;
        }catch(error){
            return initialValue;
        }
    });

    const setValue = (value) => {
        try{
            setStoredValue(() => {
                window.localStorage.setItem(key, value);
            });
        }catch(error){
            console.error(error);
        }
    }
    
    return [storedValue, setValue];
}