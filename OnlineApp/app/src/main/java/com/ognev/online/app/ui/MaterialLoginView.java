package com.ognev.online.app.ui;

import android.animation.AnimatorSet;
import android.animation.ObjectAnimator;
import android.annotation.TargetApi;
import android.content.Context;
import android.content.res.TypedArray;
import android.graphics.Matrix;
import android.graphics.Path;
import android.graphics.PathMeasure;
import android.graphics.RectF;
import android.os.Build;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.TextInputLayout;
import android.support.v4.app.FragmentActivity;
import android.support.v4.content.ContextCompat;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.view.View;
import android.view.animation.AccelerateInterpolator;
import android.view.animation.Animation;
import android.view.animation.Transformation;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.TextView;
import com.ognev.online.app.R;
import com.wdullaer.materialdatetimepicker.date.DatePickerDialog;
import io.codetail.animation.SupportAnimator;
import io.codetail.animation.ViewAnimationUtils;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;

/**
 * Created by shem on 1/15/16.
 */
public class MaterialLoginView extends FrameLayout implements DatePickerDialog.OnDateSetListener {

    private MaterialLoginViewListener listener;

    private TextView registerBtn;
    private TextView registerTitle;
    private TextInputLayout registerEmail;
    private TextInputLayout registerPass;
    private TextInputLayout registerPassRep;
    private TextView loginTitle;
    private TextInputLayout loginUser;
    private TextInputLayout loginPass;
//    private TextInputLayout login;
    private EditText birthDate;
    private TextView loginBtn;
    private FloatingActionButton registerFab;
    private View registerCancel;
    private View loginView;
    private View loginCard;
    private View registerView;
    private View registerCard;
    private TextInputLayout registerFirstName;
    private TextInputLayout registerLastName;
    private Calendar mCalendar;
    private Context context;
    private SimpleDateFormat mDateFormat;
    private FragmentActivity activity;

    public MaterialLoginView(Context context) {
        this(context, null);
    }

    public MaterialLoginView(Context context, AttributeSet attrs) {
        this(context, attrs, 0);
        this.context = context;
    }

    public MaterialLoginView(Context context, AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        init(context, attrs);
        this.context = context;
    }

    @TargetApi(Build.VERSION_CODES.LOLLIPOP)
    public MaterialLoginView(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr, defStyleRes);
        init(context, attrs);
        this.context = context;
    }

    private void init(Context context, AttributeSet attrs) {
        mDateFormat = new SimpleDateFormat(
            context.getString(R.string.birth_date_format),
            new Locale("ru")); //todo
        mCalendar = Calendar.getInstance();

        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        inflater.inflate(R.layout.login_view, this, true);
        this.context = context;

        loginView = findViewById(R.id.login_window);
        loginCard = findViewById(R.id.login_card);
        loginTitle = (TextView) findViewById(R.id.login_title);
        loginUser = (TextInputLayout) findViewById(R.id.login_user);
        loginPass = (TextInputLayout) findViewById(R.id.login_pass);
//        login = (TextInputLayout) findViewById(R.id.login_et);
        birthDate = (EditText) findViewById(R.id.birth_date);
        birthDate.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                DatePickerDialog dpd = DatePickerDialog.newInstance(
                    MaterialLoginView.this,
                    mCalendar.get(Calendar.YEAR),
                    mCalendar.get(Calendar.MONTH),
                    mCalendar.get(Calendar.DAY_OF_MONTH)
                );

                dpd.setAccentColor(ContextCompat.getColor(getContext(), R.color.color_primary));
                dpd.show(activity.getFragmentManager(), DatePickerDialog.class.getSimpleName());
            }
        });

        loginBtn = (TextView) findViewById(R.id.login_btn);

        registerView = findViewById(R.id.register_window);
        registerCard = findViewById(R.id.register_card);
        registerTitle = (TextView) findViewById(R.id.register_title);
        registerEmail = (TextInputLayout) findViewById(R.id.register_email);
        registerPass = (TextInputLayout) findViewById(R.id.register_pass);
        registerPassRep = (TextInputLayout) findViewById(R.id.register_pass_rep);
        registerFirstName = (TextInputLayout) findViewById(R.id.register_first_name);
        registerLastName = (TextInputLayout) findViewById(R.id.register_last_name);
        registerBtn = (TextView) findViewById(R.id.register_btn);

        registerFab = (FloatingActionButton) findViewById(R.id.register_fab);
        registerCancel = findViewById(R.id.register_cancel);


        registerBtn.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                listener.onRegister(registerFirstName, registerLastName, registerEmail, registerPass, registerPassRep);
            }
        });

        loginBtn.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                listener.onLogin(loginUser, loginPass);
            }
        });

        registerFab.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                animateRegister();
            }
        });

        registerCancel.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                animateLogin();
            }
        });


        TypedArray a = context.getTheme().obtainStyledAttributes(
                attrs,
                R.styleable.MaterialLoginView,
                0, 0);

        try {
            String string = a.getString(R.styleable.MaterialLoginView_loginTitle);
            if (string != null) {
                loginTitle.setText(string);
            }

            string = a.getString(R.styleable.MaterialLoginView_loginHint);
            if (string != null) {
                loginUser.setHint(string);
            }

            string = a.getString(R.styleable.MaterialLoginView_loginPasswordHint);
            if (string != null) {
                loginPass.setHint(string);
            }

            string = a.getString(R.styleable.MaterialLoginView_loginActionText);
            if (string != null) {
                loginBtn.setText(string);
            }

            string = a.getString(R.styleable.MaterialLoginView_registerTitle);
            if (string != null) {
                registerTitle.setText(string);
            }

            string = a.getString(R.styleable.MaterialLoginView_registerHint);
            if (string != null) {
                registerEmail.setHint(string);
            }

            string = a.getString(R.styleable.MaterialLoginView_registerPasswordHint);
            if (string != null) {
                registerPass.setHint(string);
            }

            string = a.getString(R.styleable.MaterialLoginView_registerRepeatPasswordHint);
            if (string != null) {
                registerPassRep.setHint(string);
            }

            string = a.getString(R.styleable.MaterialLoginView_registerActionText);
            if (string != null) {
                registerBtn.setText(string);
            }

            int color = a.getColor(R.styleable.MaterialLoginView_loginTextColor, ContextCompat.getColor(getContext(), R.color.material_login_login_text_color));
            loginUser.getEditText().setTextColor(color);
            loginPass.getEditText().setTextColor(color);

            color = a.getColor(R.styleable.MaterialLoginView_registerTextColor, ContextCompat.getColor(getContext(), R.color.material_login_register_text_color));
            registerEmail.getEditText().setTextColor(color);
            registerPass.getEditText().setTextColor(color);
            registerPassRep.getEditText().setTextColor(color);

            registerFab.setImageResource(
                    a.getResourceId(R.styleable.MaterialLoginView_registerIcon, R.drawable.ic_add_white_24dp));
        } finally {
            a.recycle();
        }
    }
//
//    @OnClick(R.id.birth_date)
//    void onDatePickClicked() {
//
//    }

    @Override
    public void onDateSet(DatePickerDialog datePickerDialog,
                          int year, int month, int day) {
        mCalendar.set(Calendar.YEAR, year);
        mCalendar.set(Calendar.MONTH, month);
        mCalendar.set(Calendar.DAY_OF_MONTH, day);

        birthDate.setText(mDateFormat.format(mCalendar.getTime()));
    }
    private void animateRegister() {
        Path path = new Path();
        RectF rect = new RectF(-241F, -40F, 41F, 242F);
        path.addArc(rect, -45F, 180F);
        path.lineTo(-0F, -50F);
        FabAnimation fabAnimation = new FabAnimation(path);
        fabAnimation.setDuration(400);
        fabAnimation.setInterpolator(new AccelerateInterpolator());

        fabAnimation.setAnimationListener(new Animation.AnimationListener() {
            @Override
            public void onAnimationStart(Animation animation) {
                SupportAnimator animator = getCircularRevealAnimation(registerCard, registerView.getWidth() - 250, 400, 0f, 2F * registerView.getHeight());
                animator.setDuration(700);
                animator.setStartDelay(200);
                animator.addListener(new SupportAnimator.SimpleAnimatorListener() {
                    public void onAnimationStart() {
                        registerView.setVisibility(View.VISIBLE);
                    }

                    public void onAnimationEnd() {
                        loginView.setVisibility(View.GONE);
                    }
                });
                animator.start();
            }

            @Override
            public void onAnimationEnd(Animation animation) {
                registerFab.setVisibility(View.GONE);
            }

            @Override
            public void onAnimationRepeat(Animation animation) {
            }
        });

        registerFab.startAnimation(fabAnimation);
    }

    private SupportAnimator getCircularRevealAnimation(View view, int centerX, int centerY, float startRadius, float endRadius) {
        return ViewAnimationUtils.createCircularReveal(
                view, centerX, centerY, startRadius, endRadius);
    }

    public boolean isLoginOpened() {
        return loginView.getVisibility() == VISIBLE;
    }

    public void animateLogin() {
        registerCancel.animate().scaleX(0F).scaleY(0F).alpha(0F).rotation(90F).
                setDuration(200).setInterpolator(new AccelerateInterpolator()).start();
        SupportAnimator animator = getCircularRevealAnimation(registerCard, registerView.getWidth() / 2, registerView.getHeight() / 2, 1f * registerView.getHeight(), 0F);
        animator.setDuration(500);
        animator.setStartDelay(100);
        animator.addListener(new SupportAnimator.SimpleAnimatorListener() {
            public void onAnimationStart() {
                loginView.setVisibility(View.VISIBLE);
            }

            public void onAnimationEnd() {
                registerView.setVisibility(View.GONE);
                registerCancel.setScaleX(1F);
                registerCancel.setScaleY(1F);
                registerCancel.setAlpha(1F);
                registerCancel.setRotation(45F);
                registerFab.setVisibility(View.VISIBLE);

                ObjectAnimator animX = ObjectAnimator.ofFloat(registerFab, "scaleX", 0F, 1F);
                ObjectAnimator animY = ObjectAnimator.ofFloat(registerFab, "scaleY", 0F, 1F);
                ObjectAnimator alpha = ObjectAnimator.ofFloat(registerFab, "alpha", 0F, 1F);
                ObjectAnimator rotation = ObjectAnimator.ofFloat(registerFab, "rotation", 90F, 0F);
                AnimatorSet animator = new AnimatorSet();
                animator.playTogether(animX, animY, alpha, rotation);
                animator.setInterpolator(new AccelerateInterpolator());
                animator.setDuration(200);
                animator.start();
            }
        });
        animator.start();
    }

    public void setListener(MaterialLoginViewListener listener) {
        this.listener = listener;
    }

    public void setActivity(FragmentActivity activity) {
        this.activity = activity;
    }

    class FabAnimation extends Animation {
        private PathMeasure measure;
        private float[] pos;

        public FabAnimation(Path path) {
            measure = new PathMeasure(path, false);
            pos = new float[]{0, 0};
        }

        protected void applyTransformation(float interpolatedTime, Transformation t) {
            measure.getPosTan(measure.getLength() * interpolatedTime, pos, null);
            Matrix matrix = t.getMatrix();
            matrix.setTranslate(pos[0], pos[1]);
            matrix.preRotate(interpolatedTime * 45);
            t.setAlpha(1 - interpolatedTime);
        }
    }
}
