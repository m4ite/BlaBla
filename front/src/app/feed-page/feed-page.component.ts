import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommunityService } from '../Services/CommunityService/community.service';
import { Community } from '../Services/CommunityService/Community';
import { UserServiceService } from '../Services/UserService/user-service.service';
import { PostService } from '../Services/PostService/post.service';
import { Post } from '../Services/PostService/Post';
import { User } from '../Services/UserService/User';
import { PostReturn } from '../Services/PostService/PostReturn';

@Component({
  selector: 'app-feed-page',
  templateUrl: './feed-page.component.html',
  styleUrls: ['./feed-page.component.css']
})
export class FeedPageComponent implements OnInit {


  dataCommunity: Community[] = [];
  dataPost: PostReturn[] = [];
  user : User  = {
    email: '',
    nickName: '',
    wordPass: '',
    birthdate: new Date(),
    foto: '',
    cargo: 0
  };

  constructor(private router: Router, private service: CommunityService, private postService : PostService, private userService: UserServiceService) { }

  ngOnInit(): void {
    const jwt = sessionStorage.getItem("jwt") ?? ""

    this.service.getAllCommunities(jwt)
      .subscribe(res => {
        res.forEach(community => {
          this.dataCommunity.push(community)
        })
      })
    


    this.postService.getAllPosts()
      .subscribe(res => 
        {
          res.forEach(post => {
            this.dataPost.push(post)
          })
        })


        
    this.userService.getUser(jwt)
        .subscribe(res =>
          {
            this.user = res
          })

    

  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/']);
  }


  like(post : PostReturn) {
    const jwt = sessionStorage.getItem("jwt") ?? ""
      this.postService.Like(post, jwt)
        .subscribe(res => 
          {
            
          })

  }

  deslike(post : PostReturn)
  {
    const jwt = sessionStorage.getItem("jwt") ?? ""
      this.postService.Deslike(post, jwt)
        .subscribe(res => 
          {
            
          })
  }


  order()
  {
    this.dataPost.sort();
    this.router.navigate(['/feed'])
  }


}
