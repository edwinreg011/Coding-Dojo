import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  constructor(
    private _httpService : HttpService,
    private _router : Router,
    private _route : ActivatedRoute
  ) { }

  editPet: any;
  errors = [];

  ngOnInit() {
    this._route.params.subscribe((params: Params) => {
      this.getEditPet(params["id"]);
    })
  }

  getEditPet(id){
    let obs = this._httpService.getOnePet(id);
    obs.subscribe(data => {
      if(data["results"]){
        this.editPet = data["results"];
      }
    })
  }

  updatePet(){
    this.errors = [];
    let obs = this._httpService.updatePet(this.editPet);
    obs.subscribe(data => {
      if(data["results"]){
        this._router.navigate([`/pets/${this.editPet._id}`])
      }
      else if(data["errors"]){
        for(var key in data["errors"]){
          this.errors.push(data["errors"][key]["message"]);
        }
      }
    })
  }
}
