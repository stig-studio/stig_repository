import { Component, OnInit, TemplateRef, ContentChild } from '@angular/core';

@Component( {

  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']

} )

export class HomeComponent implements OnInit {

  @ContentChild( TemplateRef, { static : true } ) public templ: TemplateRef<any>;
  public test : string = "home-page";

  constructor() {
  }

  ngOnInit() {
  }
}
