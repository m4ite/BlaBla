import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Post } from './Post';
import { Community } from '../CommunityService/Community';
import { PostReturn } from './PostReturn';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  Add(post: Post, jwt: string, community: string)
  {
    return this.http.post('http://localhost:5020/post/create/'+ jwt + "/" + community, post )
  }

  Update(post : Post)
  {
    return this.http.post('http://localhost:5020/post/update', post)
  }

  getAllPosts()
  {
    return this.http.get<PostReturn[]>('http://localhost:5020/post')
  }
  
  getPostByCommunity(communityName: string)
  {
    return this.http.get<PostReturn[]>('http://localhost:5020/post/' + communityName)
  }

  Like(post: PostReturn, jwt: string)
  {
    return this.http.post('http://localhost:5020/avaliation/like/' + jwt, post)
  }

  Deslike(post: PostReturn, jwt: string)
  {
    return this.http.post('http://localhost:5020/avaliation/deslike/' + jwt, post)
  }
}
