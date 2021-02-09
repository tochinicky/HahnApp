// import { ApplicantCreated } from './messages';
// import { Applicant } from './applicant';
// import {DialogService} from 'aurelia-dialog';


// export class Welcome {
//   static inject = [DialogService];
//   applicant: Applicant;
//   constructor(public dialogService) {
//     this.dialogService = dialogService;

//   }
//   person = { 
//     familyName: this.applicant.familyName, Name: this.applicant.name,
//      address: this.applicant.address,
//      emailAdress: this.applicant.eMailAdress
//    };
//   submit(){
//     this.dialogService.open({ viewModel: Applicant, model: this.person, lock: false }).whenClosed(response => {
//       if (!response.wasCancelled) {
//         console.log('good - ', response.output);
//       } else {
//         console.log('bad');
//       }
//       console.log(response.output);
//     });
//   }
// }


