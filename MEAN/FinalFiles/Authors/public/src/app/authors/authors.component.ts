import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

  constructor(
    private _httpService: HttpService
  ) { }

  allAuthors: any;

  ngOnInit() {
    this.getAllAuthorsFromService();
  }

  getAllAuthorsFromService(){
    let obs = this._httpService.getAllAuthors();
    obs.subscribe(data => {
      if(data["results"]){
        this.allAuthors = data["results"];
      }
    })
  }

  destroyOneAuthor(id){
    let obs = this._httpService.destroyAuthor(id);
    obs.subscribe(data => {
      if(data["results"]){
        this.getAllAuthorsFromService();
      }
    })
  }

}
