import { Component, OnInit } from '@angular/core';
import { AngularWaitBarrier } from 'blocking-proxy/built/lib/angular_wait_barrier';
import { $, element } from 'protractor';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit {

  constructor() {}

  ngOnInit() {
  }

  select_page( $el ) {

    if( $el.target.className != 'nav-link active' && $el.target.className != 'nav-link' ) return;

    var class_list = document.getElementsByClassName( "active" );

    if( class_list.length > 0 ){
      class_list[0].classList.remove( "active" );
    }

    $el.srcElement.className = 'nav-link active';

  }
}
