import axios from "axios";

const authHeader = () => {
    // return authorization header with jwt token
    let user = JSON.parse(localStorage.getItem("user"));
    if (user && user.token) {
      return { Authorization: "Bearer " + user.token };
    } else {
      return {};
    }
  }
  

const apiService = (isFormData = false) => {
    let headers = {  }
    if (isFormData) {
      headers["Content-Type"] = "multipart/form-data"
    }
    const http = axios.create({ 
      baseURL: `${process.env.VUE_APP_APIURL}`,
      headers: headers
    });

    http.interceptors.request.use((request) => {
      const header = authHeader();
      if (header.Authorization) {
        request.headers.common.Authorization = header.Authorization;
      }
  
      return request;
    });
  
    http.interceptors.response.use(
      (ok_response) => {
        return ok_response;
      },
      (err_response) => {
        //erro de CORS quando não está logado e tenta acessar uma url que necessita login e ela retorna 401
        //demais erros continuam funcionando o codigo
        if (err_response.response.status == 0) {
          localStorage.removeItem("user");
          window.location.href = '/'
        } 
        return Promise.reject(err_response);
      }
    );
  
    return http;
  };
  
  export const api = apiService();
  export const apiFormData = apiService(true);
  