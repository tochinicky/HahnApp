import { HttpClient, json } from 'aurelia-fetch-client';
import { inject, NewInstance } from 'aurelia-framework';
import { Applicant } from './applicant';
import { Router } from 'aurelia-router';
//import {EventAggregator} from "aurelia-event-aggregator";

@inject(HttpClient, Router)
export class ApplicantDetail {
  //hired = null;
 // private _ea;
  private http:HttpClient;
  //controller=null;
  successMessage='';
  errorMessage=null;
  
  applicant = {
    name: '',
    familyName: '',
    address: '',
    countryOfOrigin: '',
    eMailAdress: '',
    age: null,
    hired: false
   
  };
  router: Router;
    constructor( http: HttpClient, router: Router) {
     // this._ea = ea;
      this.router = router;
      this.http=http; 
     
      
      
     // this.controller.validateTrigger=validateTrigger.change;
     
         
  }
  // submit() {
    
  // }
  // reset(){
  //   window.location.reload();
  // }
  create(): Promise<Applicant> {
    return this.http.fetch('https://localhost:44363/api/Applicant/AddApplicant',
            {
                method: 'post',
                body: json(this.applicant)
            })
            .then(response => response.json())
            .catch((error) =>
            { 
              this.errorMessage = error.response
            });
   //this.router.navigateToRoute('applicants');
   
   }
 
 /**  create() {
    
    this.http.fetch('https://localhost:44330/AddApplicant',
         {
             method: 'post',
             body: json(this.applicant)
         })
         .then(response => {
              return response.json();
      }).catch((error) =>
         { 
           this.errorMessage = error.response
        });
        this.router.navigateToRoute('applicants');
        // console.log(this.successMessage);

        // this.router.navigateToRoute('applicants');
        // this.refresh();
    } 
    **/

   /** reset() {
      window.history.back();
    }
**/
    refresh(): void {
      window.location.reload();
  }
}

