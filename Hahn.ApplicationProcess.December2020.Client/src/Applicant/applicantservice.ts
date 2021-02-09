import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { Applicant } from './applicant';


@inject(HttpClient)
export class ApplicantService {
  activeApplicant : any;
  activeApplicantId: any;

 
  constructor(private http: HttpClient) {
          
       }
   getById(id: string): Promise<Applicant> {
    return this.http.fetch('https://localhost:44363/api/Applicant/GetApplicant/' + id)
            .then(response => response.json())
            .catch(error => console.log(error));
   }
   UpdateData(activeApplicant){
            const app = {        
                      "address"  : activeApplicant.address,  
                      "name": activeApplicant.name,                           
                      "age": activeApplicant.age,
                      "countryOfOrigin": activeApplicant.countryOfOrigin,
                      "eMailAdress": activeApplicant.eMailAdress,
                      "familyName": activeApplicant.familyName,
                      "hired": activeApplicant.hired,
                      };

                      this.http.fetch('https://localhost:44363/api/Applicant/UpdateApplicant', {
                      method: "PUT",         
                      headers: {
                              'content-type': 'application/json'
                              },
                      body: JSON.stringify(app)
                    })                
                    .then(response => response.json())
                    .then(data=>{
                    this.activeApplicant=data;
                    });
                    
            }
      DeleteApplicant(activeApplicantId)
            {       
                     
                    this.http.fetch('https://localhost:44363/api/Applicant/DeleteApplicant'+ activeApplicantId, {
                     method: "DELETE",         
                     headers: {
                                'content-type': 'application/json'
                              }
                    })                
                    .then(response => response.json())
                    .then(data => {        
                     this.activeApplicant = data;
                  });               
            }         
   }

