import { Injectable } from '@angular/core';
import { Member } from './Member';
import { HttpClient } from '@angular/common/http';
import { User } from '../UserService/User';
import { Community } from '../CommunityService/Community';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  constructor(private http: HttpClient) { }

  getAllUsers(title: string) {
    return this.http.get<User[]>("http://localhost:5020/member/" + title);
  }

  getAllMembers(title: string) {
    return this.http.get<User[]>("http://localhost:5020/member/list/" + title);
  }

  Connect(community: Community, jwt: string)
  {
    return this.http.post('http://localhost:5020/member/create/'+ jwt , community )
  }

  getRelation(communityTitle : string, jwt : string )
  {
    return this.http.get<boolean>('http://localhost:5020/member/getRelation/'+ jwt + "/" + communityTitle)
  }

  getAll(communityTitle : string, jwt : string )
  {
    return this.http.get<User[]>('http://localhost:5020/member/getAll/'+ jwt + "/" + communityTitle)
  }

  
}
