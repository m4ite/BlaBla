import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from '../Services/UserService/user-service.service';
import { User } from '../Services/UserService/User';
import { Login } from '../Services/UserService/Login';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css'],
  providers: [UserServiceService]
})
export class LoginPageComponent {
  email = "";
  password = "";
  logo = '../assets/logo.png';

  constructor(private router: Router, private service: UserServiceService) { }

  ngOnInit(): void {
    sessionStorage.clear()
  }

  login() {
    sessionStorage.clear()

    let user: Login = {
      email: this.email,
      wordPass: this.password,
    };

    let router = this.router;

    this.service.Login(user).subscribe({
      next(value) {
        if (!value.token) {
          return
        }

        sessionStorage.setItem("jwt", value.token)

        const isSetted = sessionStorage.getItem("jwt")
    
        if (isSetted)
          router.navigate(['/feed']);
      }
    })
  }
}