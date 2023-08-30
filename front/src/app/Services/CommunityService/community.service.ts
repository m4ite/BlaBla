import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Community } from './Community';
import { Post } from '../PostService/Post';
import { User } from '../UserService/User';
import { CommunityResult } from './CommunityResult';

@Injectable({
  providedIn: 'root'
})
export class CommunityService {

  constructor(private http: HttpClient) { }

  Add(community: Community, jwt: string)
  {
    return this.http.post('http://localhost:5020/community/create/' + jwt, community)
  }

  getUser(jwt: string)
  {
    return this.http.get<User>("http://localhost:5020/getUser/" + jwt);
  }

  getAllCommunities(jwt: string) {
    return this.http.get<Community[]>("http://localhost:5020/community/" + jwt);
  }

  getCommunity(title: string, jwt: string)
  {
    return this.http.get<Community>("http://localhost:5020/community/manage/" + title);
  }

  getCommunityResult(title: string, jwt: string)
  {
    return this.http.get<CommunityResult>("http://localhost:5020/community/manage/result/" + title);
  }

}