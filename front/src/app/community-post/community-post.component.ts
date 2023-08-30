import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommunityService } from '../Services/CommunityService/community.service';
import { PostService } from '../Services/PostService/post.service';
import { Post } from '../Services/PostService/Post';
import { MemberService } from '../Services/MemberService/member.service';
import { Community } from '../Services/CommunityService/Community';
import { User } from '../Services/UserService/User';
import { Member } from '../Services/MemberService/Member';
import { HttpErrorResponse, HttpRequest, HttpResponse } from '@angular/common/http';
import { CommunityResult } from '../Services/CommunityService/CommunityResult';
import { PostReturn } from '../Services/PostService/PostReturn';

@Component({
  selector: 'app-community-post',
  templateUrl: './community-post.component.html',
  styleUrls: ['./community-post.component.css']
})
export class CommunityPostComponent {
  constructor(
    private router: Router,
    private service: CommunityService,
    private route: ActivatedRoute,
    private postService: PostService,
    private memberService: MemberService) { }

  communityTitle = ""
  qtd = 0
  validation = false
  erro = ""
  subscription: any;
  dataPost: PostReturn[] = []
  dataMember: User[] = []
  dataRelation: Member[] = []

  community: Community =
    {
      title: '',
      descrip: '',
      foto: '',
    }

  communityResult: CommunityResult =
    {
      title: '',
      descrip: '',
      foto: '',
      owner: ''
    }

  ngOnInit(): void {
    const jwt = sessionStorage.getItem("jwt") ?? ""
    this.subscription = this.route.params.subscribe(params => {
      this.communityTitle = params['title'];
    });

    this.postService.getPostByCommunity(this.communityTitle)
      .subscribe(res => {
        res.forEach(post => {
          this.dataPost.push(post);
        });
      })

    this.service.getCommunityResult(this.communityTitle, jwt)
      .subscribe(res => {
        this.communityResult.foto = res.foto
        this.communityResult.descrip = res.descrip
        this.communityResult.title = res.title
        this.communityResult.owner = res.owner
      })
      console.log("Community result: ",this.communityResult);
      

    this.service.getCommunity(this.communityTitle, jwt)
      .subscribe(res => {
        this.community.foto = res.foto
        this.community.descrip = res.descrip
        this.community.title = res.title
      })
      console.log("Community: ",this.community);

      

    this.memberService.getAllMembers(this.communityTitle)
      .subscribe(res => {
        res.forEach(element => {
          this.dataMember.push(element);
          console.log(element)
          this.qtd++
        });
      })


    this.memberService.getRelation(this.communityTitle, jwt)
      .subscribe(res => {
        this.validation = res;
      })
    
  }

  


  like(post: PostReturn) {
   
  }



  deslike(post: PostReturn) {
    
   
  }



  connect(community: Community) {
    const jwt = sessionStorage.getItem("jwt") ?? ""
    this.memberService.Connect(community, jwt)
      .subscribe(res => {
        console.log("Join")
        this.router.navigate(["/feed"]);
      })
  }


}
