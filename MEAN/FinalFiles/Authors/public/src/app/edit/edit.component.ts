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
    private _httpService: HttpService,
    private _router: Router,
    private _route: ActivatedRoute
  ) { }

  editAuthor: any;
  errors = [];

  ngOnInit() {
    this._route.params.subscribe((params: Params) => {
      this.getEditAuthor(params["id"]);
    })
  }

  getEditAuthor(id){
    let obs = this._httpService.getOneAuthor(id);
    obs.subscribe(data => {
      if(data["results"]){
        this.editAuthor = data["results"];
      }
    })
  }

  updateAuthor(){
    this.errors = []; 
    let obs = this._httpService.updateAuthor(this.editAuthor);
    obs.subscribe(data => {
      if(data["results"]){
        this._router.navigate(['/']);
      }
      else if(data["errors"]){
        for(var key in data["errors"]){
          this.errors.push(data["errors"][key]["message"]);
        }
      }
    })
  }
}
