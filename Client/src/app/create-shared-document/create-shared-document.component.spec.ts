import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSharedDocumentComponent } from './create-shared-document.component';

describe('CreateSharedDocumentComponent', () => {
  let component: CreateSharedDocumentComponent;
  let fixture: ComponentFixture<CreateSharedDocumentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateSharedDocumentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateSharedDocumentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
