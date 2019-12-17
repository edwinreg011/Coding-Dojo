import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) { }

  getAllPets(){
    return this._http.get('/api/pets');
  }

  getOnePet(id){
    return this._http.get(`/api/pets/${id}`);
  }

  createPet(newPet){
    return this._http.post('/api/pets/create', newPet);
  }

  updatePet(updatePet){
    return this._http.put(`/api/pets/update/${updatePet._id}`, updatePet);
  }

  destroyPet(id){
    return this._http.delete(`/api/pets/destroy/${id}`);
  }

}
