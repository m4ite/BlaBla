import { Component } from '@angular/core';
import { UserServiceService } from '../Services/UserService/user-service.service';
import { User } from '../Services/UserService/User';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-new-account-page',
  templateUrl: './new-account-page.component.html',
  styleUrls: ['./new-account-page.component.css']
})
export class NewAccountPageComponent {

  constructor(private userService: UserServiceService, private router: Router) {}

  email = "";
  nickName = "";
  password = "";
  birthDate: Date = new Date;
  photo = "";
  cargo = 1;

  validation = false
  campos = false
  erro = ""
  foto = ""

  ngOnInit(): void {
    sessionStorage.clear()
  }

  createAccount() {
    this.campos = false;
    this.validation = false;

    this.foto = this.photo

    if(this.email == "" || this.nickName == "" || this.password == "")
      this.campos = true;


    if(this.photo == "")
    {
      this.foto = "./assets/user/default.png"
    }
    else
    {
      var list = this.photo.split("\\")
      var item = list[list.length-1]
      this.foto = "./assets/user/" + item
    }
    
    let user : User =  
    {
      email: this.email,
      nickName: this.nickName,
      wordPass: this.password,
      birthdate: this.birthDate,
      foto: this.foto,
      cargo : this.cargo
    };


    this.userService.Add(user)
      .subscribe({
        next: (res: any) => {
        this.router.navigate(["/"]);
        },
        error: (error: HttpErrorResponse) => {
          this.erro = error.error
          
          if(!this.campos)
            this.validation = true
        }
      })
  }

}
