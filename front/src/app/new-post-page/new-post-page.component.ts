import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PostService } from '../Services/PostService/post.service';
import { Post } from '../Services/PostService/Post';
import { CommunityService } from '../Services/CommunityService/community.service';
import { Community } from '../Services/CommunityService/Community';

@Component({
  selector: 'app-new-post-page',
  templateUrl: './new-post-page.component.html',
  styleUrls: ['./new-post-page.component.css']
})
export class NewPostPageComponent {

  title = ""
  description = ""
  photo = ""

  foto = ""

  communityName = ""
  subscription: any;

  community : Community = 
  {
    title: '',
    descrip: '',
    foto: ''
  }

  constructor(private postService: PostService, private router: Router, private route: ActivatedRoute, private communityService: CommunityService) {}

  ngOnInit(): void
  {
    const jwt = sessionStorage.getItem("jwt") ?? ""

    this.subscription = this.route.params.subscribe(params => {
      this.communityName = params['communityName'];
      });

    this.communityService.getCommunity(this.communityName, jwt)
      .subscribe(res =>
      {
        this.community.foto = res.foto
        this.community.title = res.title
      })

    
  }
  
  publish() {

    const jwt = sessionStorage.getItem("jwt")
    console.log("jwt", jwt)

    if (this.photo != "") {
      var list = this.photo.split("\\")
      var item = list[list.length-1]
      this.foto = "./assets/post/" + item
    }

    let post : Post = 
    {
      title: this.title,
      descrip : this.description,
      foto : this.foto
    };

    console.log(post)

    this.postService.Add(post, jwt!, this.community.title)
      .subscribe(res => {
        console.log("oie")
         this.router.navigate(["/feed"]);
      });

  }

}
