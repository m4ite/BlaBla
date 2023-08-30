import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginPageComponent } from './login-page/login-page.component';
import { NewAccountPageComponent } from './new-account-page/new-account-page.component';
import { FeedPageComponent } from './feed-page/feed-page.component';
import { NewCommunityPageComponent } from './new-community-page/new-community-page.component'; 
import { CommunityManagementPageComponent } from './community-management-page/community-management-page.component';
import { MembersPageComponent } from './members-page/members-page.component';
import { NewPostPageComponent } from './new-post-page/new-post-page.component';
import { EditMemberPageComponent } from './edit-member-page/edit-member-page.component';
import { CreateCargoPageComponent } from './create-cargo-page/create-cargo-page.component';
import { CommunityPostComponent } from './community-post/community-post.component';
import { CommunitySearchComponent } from './community-search/community-search.component';


const routes: Routes = [
  { path: "", title: "Login", component: LoginPageComponent},
  { path: "createAccount", title: "Create Account", component: NewAccountPageComponent},
  { path: "feed", title: "Feed", component: FeedPageComponent},
  { path: "newCommunity", title: "Create Community", component: NewCommunityPageComponent},
  { path: "membersList/:title", title: "Members", component: MembersPageComponent},
  { path: "addPost/:communityName", title: "Create Post", component: NewPostPageComponent},
  { path: "editMember/:nickName/:communityName", title: "Edit Members", component: EditMemberPageComponent},
  { path: "createCargo/:communityName", title: "New Cargo", component: CreateCargoPageComponent},
  { path: "manageCommunity/:title", title: "Manage Community", component: CommunityManagementPageComponent },
  { path: "communityPost/:title", title: "Community Home", component: CommunityPostComponent },
  { path: "searchCommunity/:communityName", title: "Community Discovery", component: CommunitySearchComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
