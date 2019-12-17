import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) { }

  getAllAuthors(){
    return this._http.get('/api/authors');
  }

  getOneAuthor(id){
    return this._http.get(`/api/authors/${id}`);
  }

  createAuthor(newAuthor){
    return this._http.post('/api/authors/create', newAuthor);
  }

  updateAuthor(updateAuthor){
    return this._http.put(`/api/authors/update/${updateAuthor._id}`, updateAuthor);
  }

  destroyAuthor(id){
    return this._http.delete(`/api/authors/destroy/${id}`);
  }
  
}
