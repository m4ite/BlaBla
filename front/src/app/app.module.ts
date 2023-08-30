import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { NewAccountPageComponent } from './new-account-page/new-account-page.component';
import { FeedPageComponent } from './feed-page/feed-page.component';
import { NewCommunityPageComponent } from './new-community-page/new-community-page.component';
import { CommunityManagementPageComponent } from './community-management-page/community-management-page.component';
import { MembersPageComponent } from './members-page/members-page.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NewPostPageComponent } from './new-post-page/new-post-page.component';
import { EditMemberPageComponent } from './edit-member-page/edit-member-page.component';
import { UserServiceService } from './Services/UserService/user-service.service';
import { HttpClientModule } from '@angular/common/http';
import { CreateCargoPageComponent } from './create-cargo-page/create-cargo-page.component';
import { CommunityPostComponent } from './community-post/community-post.component';
import { CommunitySearchComponent } from './community-search/community-search.component';




@NgModule({
  declarations: [
    AppComponent,
    NewAccountPageComponent,
    FeedPageComponent,
    LoginPageComponent,
    NewCommunityPageComponent,
    CommunityManagementPageComponent,
    MembersPageComponent,
    NewPostPageComponent,
    EditMemberPageComponent,
    CreateCargoPageComponent,
    CommunityPostComponent,
    CommunitySearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    HttpClientModule 
  ],
  providers: [UserServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
