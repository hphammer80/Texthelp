import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TexthelpFormComponent } from './texthelp-form.component';

describe('TexthelpFormComponent', () => {
  let component: TexthelpFormComponent;
  let fixture: ComponentFixture<TexthelpFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TexthelpFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TexthelpFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
