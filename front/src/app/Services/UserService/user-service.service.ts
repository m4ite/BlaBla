import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './User';
import { Login } from './Login';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  constructor(private http: HttpClient) { }

  Add(user: User) {
    return this.http.post<String>('http://localhost:5020/user/sign', user)
  }


  getUser(jwt: string) {
    return this.http.get<User>("http://localhost:5020/user/" + jwt);
  }

  Login(user: Login) {
    return this.http.post<LoginResult>("http://localhost:5020/login/entrar", user);
  }

  getMember(name: string )
  {
    return this.http.get<User>("http://localhost:5020/member/member/" + name);
  }

  submit(user: User, cargo: string, communityName: string)
  {
    return this.http.post("http://localhost:5020/member/update/"+ cargo + "/" + communityName, user);
  }

 
}

interface LoginResult {
  token: string
}