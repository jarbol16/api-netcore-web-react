import axios from 'axios';
const baseUrl = "https://localhost:5001/api";

export const signIn = async ({user, pass}) => {
    console.log(user, pass);
    const response = await axios.post(`${baseUrl}/Users/UserValidate`, {
        userName: user,
        password: pass
    });
    return response.data;
}

export const users = async (user) => {
    const response = await axios.post(`${baseUrl}/Users/Users?userName=${user}`);
    return response.data;
}

export const persons = async (user) => {
    const response = await axios.get(`${baseUrl}/Person/GetPersons?userName=${user}`);
    console.log(response);
    return response.data;
}


export const roles = async () => {
    const response = await axios.get(`${baseUrl}/Roles/GetRoles`);
    return response.data;
}

export const permissions = async () => {
    const response = await axios.get(`${baseUrl}/Roles/GetPermisions`);
    return response.data;
}