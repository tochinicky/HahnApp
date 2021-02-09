export class Applicant {
  id: string;
  name: string;
  familyName: string;
  address: string;
  countryOfOrigin: string;
  eMailAdress: string;
  age:number;
  hired:boolean

  constructor(data) {
      Object.assign(this, data);
  }

  /**getAddress() {
      return `${this.address} ${this.city}, ${this.state} ${this.postalCode}`;
  }
  **/

}
