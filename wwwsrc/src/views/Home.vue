<template>
  <div class="home container-fluid text-success">
    <div class="row mt-4">
      <div class="col-4 pb-3 mx-auto border-bottom border-primary text-center text-success">
        <h1>WELCOME TO KEEPR</h1>
      </div>
    </div>
#region cards
    <div class="row mt-3 justify-content-center">
      <div class="card-columns">
        <div class="card mx-2 shadow text-dark my-2">
          <img class="card-img-top" src="https://cdn.motor1.com/images/mgl/g6wem/s1/most-expensive-lead.jpg" alt="">
          <div class="card-body">
            <h4 class="card-title">Keep1</h4>
            <p class="card-text">this is the first keep</p>
          </div>
        </div>
        <div class="card mx-2 shadow text-dark my-2">
          <img class="card-img-top" src="https://static01.nyt.com/images/2020/05/07/fashion/30rats-1-still/30rats-1-still-superJumbo.jpg" alt="">
          <div class="card-body">
            <h4 class="card-title">Keep1</h4>
            <p class="card-text">this is the first keep</p>
          </div>
        </div>
        <div class="card mx-2 shadow bg-primary text-dark my-2">
          <img class="card-img-top" src="https://static.scientificamerican.com/sciam/cache/file/4E0744CD-793A-4EF8-B550B54F7F2C4406_source.jpg" alt="">
          <div class="card-body">
            <h4 class="card-title">Keep1</h4>
            <p class="card-text">this is the first keep</p>
          </div>
        </div>
        <div class="card mx-2 shadow text-dark my-2">
          <img class="card-img-top" src="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcS4NY7MqQgy-ZUDXg3J8YFM1FueN0FquoRIEQ&usqp=CAU" alt="">
          <div class="card-body">
            <h4 class="card-title">Keep1</h4>
            <p class="card-text">this is the first keep</p>
          </div>
        </div>
        
        <div class="card mx-2 shadow text-dark my-2">
          <img class="card-img-top" src="https://srcnaut.com/cdn-cgi/image/f=auto,fit=crop,g=0.5x0.5,w=2000,h=1125,q=90,d=1/upload/16/4e/3d/shutterstock-1724432170.jpg" alt="">
          <div class="card-body">
            <h4 class="card-title">Keep1</h4>
            <p class="card-text">this is the first keep</p>
          </div>
        </div>
        <div class="card mx-2 shadow text-dark my-2">
          <img class="card-img-top" src="https://pbs.twimg.com/profile_images/923988782847737856/0_SvqBVa_400x400.jpg" alt="">
          <div class="card-body">
            <h4 class="card-title">Keep1</h4>
            <p class="card-text">this is the first keep</p>
          </div>
        </div>
        <div class="card mx-2 shadow text-dark my-2">
          <img class="card-img-top" src="https://images.unsplash.com/photo-1539901241555-2bd95a83dc6e?ixlib=rb-1.2.1&w=1000&q=80" alt="">
          <div class="card-body">
            <h4 class="card-title">Keep1</h4>
            <p class="card-text">this is the first keep</p>
          </div>
        </div>
        <div class="card mx-2 shadow text-dark my-2">
          <img class="card-img-top" src="https://static.scientificamerican.com/sciam/cache/file/4E0744CD-793A-4EF8-B550B54F7F2C4406_source.jpg" alt="">
          <div class="card-body">
            <h4 class="card-title">Keep1</h4>
            <p class="card-text">this is the first keep</p>
          </div>
        </div>
        #endregion
      </div>
    </div>

  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>
<style>
.card-columns{
  column-count: 5;
}
.card{
  background-color: #EEEEEE;
}
</style>
