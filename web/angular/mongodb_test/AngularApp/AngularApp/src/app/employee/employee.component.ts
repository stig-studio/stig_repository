import { Component, OnInit } from '@angular/core';

import { EmployeeService } from '../shared/employee.service';
import { NgForm } from '@angular/forms';
import { Employee } from '../shared/employee.model';

declare var m: any;

@Component( {

  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  providers: [EmployeeService]

} )

export class EmployeeComponent implements OnInit {

  constructor( private employeeService: EmployeeService ) { }

  ngOnInit() {
    this.resetForm();

  }

  resetForm( form?: NgForm ) {

    console.log( form );

    if( form ) {
      form.reset();
      this.refreshEmployeeList();
    }

    this.employeeService.selectedEmployee = {

      _id: "",
      name: "",
      position: "",
      office: "",
      salary: null

    };
  }

  onSubmit( form: NgForm ){

    console.log( 'submit' );

    this.employeeService.postEmployee( form.value ).subscribe( ( res ) => {

      this.resetForm( form );
      m.toast( {html: 'Saved successfully', classes: 'rounded'} );

    } );

  }

  refreshEmployeeList() {

    this.employeeService.getEmployeeList().subscribe((res) => {
      this.employeeService.employees = res as Employee[];
    });
  }

}
