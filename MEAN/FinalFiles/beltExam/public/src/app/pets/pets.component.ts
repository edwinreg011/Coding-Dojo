import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent implements OnInit {

  constructor(
    private _httpService: HttpService
  ) { }

  allPets: any;

  ngOnInit() {
    this.getAllPetsFromService();
  }

  getAllPetsFromService(){
    let obs = this._httpService.getAllPets();
    obs.subscribe(data => {
      if(data["results"]){
        this.allPets = data["results"];
      }
    })
  }
}
